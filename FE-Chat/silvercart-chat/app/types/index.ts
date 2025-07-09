export interface Message {
  conversationId: string;
  content: string;
}

export interface ApiResponse<T> {
  statusCode: number;
  data: T;
  message?: string;
}

export interface ConversationResponse {
  conversations: Conversation[];
}

export interface Conversation {
  id: string;
  name: string;
  lastMessage: string;
  lastMessageAt: string;
  unreadCount: number;
}

export interface User {
  id: string;
  role: string;
} 