'use client';

import { useState, useEffect, useCallback, useRef } from 'react';
import { Message, Conversation } from '../types';
import { useAuth } from '../hooks/useAuth';
import { api } from '../services/api';
import { chatService } from '../services/chatService';
import { ChatMessage } from '../components/ChatMessage';
import { ConversationList } from '../components/ConversationList';
import { useRouter } from 'next/navigation';

export default function ChatPage() {
  const router = useRouter();
  const { user, loading, isAuthenticated } = useAuth();

  const [messages, setMessages] = useState<Message[]>([]);
  const [conversations, setConversations] = useState<Conversation[]>([]);
  const [selectedConversation, setSelectedConversation] = useState<string>('');
  const [newMessage, setNewMessage] = useState('');
  const [isSending, setIsSending] = useState(false);
  const [connectionState, setConnectionState] = useState<'connected' | 'connecting' | 'disconnected'>('connecting');

  const messageSound = useRef(new Audio('/message.mp3'));
  const messagesEndRef = useRef<HTMLDivElement>(null);

  // NEW: useRef giữ selectedConversation mới nhất
  const selectedConversationRef = useRef(selectedConversation);
  useEffect(() => {
    selectedConversationRef.current = selectedConversation;
  }, [selectedConversation]);

  const scrollToBottom = () => {
    messagesEndRef.current?.scrollIntoView({ behavior: 'smooth' });
  };

  const loadConversations = useCallback(async () => {
    try {
      const response = await api.getConversations();
      const newConversations = response.data.conversations;

      setConversations((prev) => {
        if (JSON.stringify(prev) !== JSON.stringify(newConversations)) {
          return newConversations;
        }
        return prev;
      });

      if (!selectedConversation && newConversations.length > 0) {
        setSelectedConversation(newConversations[0].id);
      }
    } catch (error) {
      console.error('Error loading conversations:', error);
    }
  }, [selectedConversation]);

  const loadMessages = useCallback(async (conversationId: string) => {
    try {
      const data = await api.getMessages(conversationId);
      setMessages(data.data);
      setTimeout(scrollToBottom, 100);
    } catch (error) {
      console.error('Error loading messages:', error);
    }
  }, []);

  // CHANGED: handleNewMessage không dùng selectedConversation trực tiếp mà dùng ref
  const handleNewMessage = useCallback(
    async (message: Message) => {
      if (message.conversationId === selectedConversationRef.current) {
        setMessages((prev) => {
          if (!prev.some((m) => m.id === message.id)) {
            setTimeout(scrollToBottom, 100);
            return [...prev, message];
          }
          return prev;
        });

        if (message.senderId !== localStorage.getItem('userId')) {
          try {
            await messageSound.current.play();
          } catch (err) {
            console.log('Error playing sound:', err);
          }
        }
      }

      await loadConversations();
    },
    [loadConversations]
  );

  // Khởi tạo chat + connection, effect này chỉ chạy 1 lần khi loading false & isAuthenticated true
  useEffect(() => {
    if (loading) return;
    if (!isAuthenticated) {
      router.push('/login');
      return;
    }

    let unsubscribe: () => void;
    
    const initialize = async () => {
      try {
        setConnectionState('connecting');
        await chatService.startConnection();
        setConnectionState('connected');

        unsubscribe = chatService.onMessage(handleNewMessage);
        await loadConversations();
      } catch (error) {
        console.error('Error initializing chat:', error);
        setConnectionState('disconnected');
      }
    };

    void initialize();

    return () => {
      if (unsubscribe) unsubscribe();
      void chatService.stopConnection();
    };
  }, [loading, isAuthenticated, handleNewMessage, loadConversations, router]);

  useEffect(() => {
    if (!selectedConversation) return;

    let mounted = true;

    const handleChange = async () => {
      try {
        if (mounted) {
          await loadMessages(selectedConversation);
          await chatService.joinConversation(selectedConversation);
        }
      } catch (error) {
        console.error('Error changing conversation:', error);
      }
    };

    void handleChange();

    return () => {
      mounted = false;
      void chatService.leaveConversation(selectedConversation);
    };
  }, [selectedConversation, loadMessages]);

  const handleSendMessage = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!newMessage.trim() || !selectedConversation || isSending) return;
  
    try {
      setIsSending(true);
  
      await chatService.sendMessage(selectedConversation, newMessage.trim());
  
      setNewMessage('');
    } catch (error) {
      console.error('Error sending message:', error);
    } finally {
      setIsSending(false);
    }
  };

  if (loading) {
    return <div className="flex items-center justify-center h-screen">Loading...</div>;
  }

  if (!isAuthenticated) {
    return null;
  }

  return (
    <div className="flex h-screen bg-gray-100">
      <ConversationList
        conversations={conversations}
        selectedId={selectedConversation}
        onSelect={setSelectedConversation}
        onConversationCreated={() => void loadConversations()}
      />

      <div className="flex-1 flex flex-col">
        <div className="bg-white shadow-sm p-4 border-b border-gray-200 flex justify-between items-center">
          <h1 className="text-xl font-bold text-gray-900">
            {conversations.find((c) => c.id === selectedConversation)?.name || 'Chat'}
          </h1>
          {connectionState !== 'connected' && (
            <span className="text-sm text-gray-500 italic">
              {connectionState === 'connecting' ? 'Đang kết nối...' : 'Mất kết nối'}
            </span>
          )}
        </div>

        <div className="flex-1 overflow-y-auto p-4 space-y-4 bg-gray-50">
          {messages.map((message) => (
            <ChatMessage
              key={message.id}
              message={message}
              isOwnMessage={message.senderId === localStorage.getItem('userId')}
            />
          ))}
          <div ref={messagesEndRef} />
        </div>

        <form onSubmit={handleSendMessage} className="bg-white p-4 border-t border-gray-200">
          <div className="flex space-x-2">
            <input
              type="text"
              value={newMessage}
              onChange={(e) => setNewMessage(e.target.value)}
              placeholder="Type your message..."
              className="flex-1 px-4 py-2 border border-gray-300 rounded-full focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent"
              disabled={isSending || connectionState !== 'connected'}
            />
            <button
              type="submit"
              className={`${
                isSending ? 'bg-blue-400' : 'bg-blue-600 hover:bg-blue-700'
              } text-white px-6 py-2 rounded-full focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 transition-colors`}
              disabled={isSending || connectionState !== 'connected'}
            >
              {isSending ? 'Sending...' : 'Send'}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}
