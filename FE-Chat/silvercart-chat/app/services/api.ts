import { Message, Conversation } from '../types';
import { ApiResponse, ConversationResponse } from '../types/index';

const API_BASE_URL = 'https://localhost:5001/api';

export const api = {
  login: async (email: string, password: string) => {
    try {
      const response = await fetch(`${API_BASE_URL}/auth/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password }),
      });
      
      if (!response.ok) {
        const errorData = await response.json();
        throw new Error(errorData.message || 'Login failed');
      }
      
      const responseData = await response.json();
      return responseData;
    } catch (error) {
      console.error('Login request failed:', error);
      throw error;
    }
  },

  // Messages
  getMessages: async (conversationId: string): Promise<ApiResponse<Message[]>> => {
    try {
      const response = await fetch(`${API_BASE_URL}/Message/conversations?ConversationId=${conversationId}`, {
        headers: { Authorization: `Bearer ${localStorage.getItem('accessToken')}` },
      });
      
      if (!response.ok) {
        const errorData = await response.json();
        throw new Error(errorData.message || 'Failed to get messages');
      }
      
      return response.json();
    } catch (error) {
      console.error('Get messages failed:', error);
      throw error;
    }
  },

  sendMessage: async (message: Partial<Message>): Promise<ApiResponse<Message>> => {
    try {
      const response = await fetch(`${API_BASE_URL}/Message`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${localStorage.getItem('accessToken')}`,
        },
        body: JSON.stringify(message),
      });

      if (!response.ok) {
        const errorData = await response.json();
        throw new Error(errorData.message || 'Failed to send message');
      }

      return response.json();
    } catch (error) {
      console.error('Send message failed:', error);
      throw error;
    }
  },

  // Conversations
  getConversations: async (): Promise<ApiResponse<ConversationResponse>> => {
    try {
      const response = await fetch(`${API_BASE_URL}/conversation?UserId=${localStorage.getItem('userId')}`, {
        headers: { Authorization: `Bearer ${localStorage.getItem('accessToken')}` },
        method: 'GET',
      });

      if (!response.ok) {
        const errorData = await response.json();
        throw new Error(errorData.message || 'Failed to get conversations');
      }

      return response.json();
    } catch (error) {
      console.error('Get conversations failed:', error);
      throw error;
    }
  },

  createConversation: async (partnerEmail: string): Promise<ApiResponse<Conversation>> => {
    try {
      const response = await fetch(`${API_BASE_URL}/conversation`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${localStorage.getItem('accessToken')}`,
        },
        body: JSON.stringify({
          partnerEmail
        }),
      });

      if (!response.ok) {
        const errorData = await response.text();
        throw new Error(errorData || 'Failed to create conversation');
      }

      const data = await response.json();
      return data;
    } catch (error) {
      console.error('Create conversation failed:', error);
      throw error;
    }
  },
}; 