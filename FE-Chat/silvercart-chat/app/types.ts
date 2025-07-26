export interface Message {
  id: string;
  conversationId: string;
  senderId: string;
  content: string;
  creationDate: string;
  isRead: boolean;
  isModified: boolean;
  isDeleted: boolean;
}

export interface Conversation {
  id: string;
  name: string;
  lastMessage: string;
  lastMessageAt: string;
  unreadCount: number;
} 