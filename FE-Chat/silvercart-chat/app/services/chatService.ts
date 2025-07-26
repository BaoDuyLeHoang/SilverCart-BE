import * as signalR from '@microsoft/signalr';

class ChatService {
  private static instance: ChatService;
  private hubConnection: signalR.HubConnection | null = null;
  private messageHandlers: Set<(message: any) => void> = new Set();
  private connectionId: string | null = null;

  private constructor() {}

  public static getInstance(): ChatService {
    if (!ChatService.instance) {
      ChatService.instance = new ChatService();
    }
    return ChatService.instance;
  }

  public async startConnection(): Promise<string | null> {
    if (this.hubConnection?.state === signalR.HubConnectionState.Connected && this.connectionId) {
      return this.connectionId;
    }

    try {
      const userId = localStorage.getItem('userId');
      const token = localStorage.getItem('accessToken');
      if (!userId || !token) {
        throw new Error('User ID or token not found');
      }

      if (!this.hubConnection) {
        this.hubConnection = new signalR.HubConnectionBuilder()
          .withUrl(`https://localhost:5001/chatHub`, {
            accessTokenFactory: () => token,
            skipNegotiation: true,
            transport: signalR.HttpTransportType.WebSockets,
            withCredentials: false,
          })
          .configureLogging(signalR.LogLevel.Warning)
          .withAutomaticReconnect()
          .build();

        this.setupMessageHandlers();
      }

      // Only start if disconnected
      if (this.hubConnection.state === signalR.HubConnectionState.Disconnected) {
        await this.hubConnection.start();

        try {
          const connId = await this.hubConnection.invoke<string>("GetConnectionId");
          this.connectionId = connId;
          console.log('Connected to chat hub. ConnectionId:', connId);
        } catch (err) {
          console.warn('Failed to get connection ID from server', err);
          this.connectionId = null;
        }
        
        console.log('Connected to chat hub. ConnectionId:', this.connectionId);
        return this.connectionId;
      }

      // Wait for connection if it's in the process of reconnecting
      for (let i = 0; i < 5; i++) {
        if (this.hubConnection.state === signalR.HubConnectionState.Connected) {
          this.connectionId = this.hubConnection.connectionId || null;
          return this.connectionId;
        }
        await new Promise(res => setTimeout(res, 500));
      }

      console.warn('Hub connection was not established after waiting.');
      return this.connectionId;

    } catch (error) {
      console.error('Error starting chat connection:', error);
      this.hubConnection = null;
      this.connectionId = null;
      throw error;
    }
  }

  private setupMessageHandlers() {
    if (!this.hubConnection) return;

    this.hubConnection.on("ReceiveMessage", (message) => {
      console.log("Received message:", message);
      this.messageHandlers.forEach((handler) => handler(message));
    });
    

    this.hubConnection.onreconnecting((error) => {
      console.log('Connection reconnecting...', error);
    });

    this.hubConnection.onreconnected((connectionId) => {
      console.log('Connection reestablished. ConnectionId:', connectionId);
      this.connectionId = connectionId || null;
    });

    this.hubConnection.onclose((error) => {
      console.log('Connection closed:', error);
      this.connectionId = null;
    });
  }

  public async sendMessage(conversationId: string, content: string) {
    if (!this.hubConnection || this.hubConnection.state !== signalR.HubConnectionState.Connected) {
      await this.startConnection();
    }

    try {
      await this.hubConnection?.invoke('SendMessage', conversationId, content);
      console.log('Message sent successfully');
    } catch (error) {
      console.error('Error sending message:', error);
      throw error;
    }
  }

  public async joinConversation(conversationId: string) {
    if (!this.hubConnection || this.hubConnection.state !== signalR.HubConnectionState.Connected) {
      await this.startConnection();
    }

    try {
      await this.hubConnection?.invoke('JoinConversation', conversationId);
      console.log(`Joined conversation: ${conversationId}`);
    } catch (error) {
      console.error('Error joining conversation:', error);
      throw error;
    }
  }

  public async leaveConversation(conversationId: string) {
    if (this.hubConnection?.state === signalR.HubConnectionState.Connected) {
      try {
        await this.hubConnection.invoke('LeaveConversation', conversationId);
        console.log(`Left conversation: ${conversationId}`);
      } catch (error) {
        console.error('Error leaving conversation:', error);
      }
    }
  }

  public onMessage(handler: (message: any) => void): () => void {
    this.messageHandlers.add(handler);
    return () => {
      this.messageHandlers.delete(handler);
    };
  }

  public async stopConnection() {
    try {
      if (this.hubConnection?.state === signalR.HubConnectionState.Connected) {
        await this.hubConnection.stop();
        console.log('Disconnected from chat hub');
      }
    } catch (error) {
      console.error('Error stopping chat connection:', error);
    } finally {
      this.messageHandlers.clear();
      this.hubConnection = null;
      this.connectionId = null;
    }
  }

  public getConnectionId(): string | null {
    return this.connectionId;
  }
}

// Export singleton instance
export const chatService = ChatService.getInstance();
