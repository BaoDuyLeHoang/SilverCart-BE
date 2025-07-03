import { Conversation } from '../types';
import { useState } from 'react';
import { api } from '../services/api';

interface ConversationListProps {
  conversations: Conversation[];
  selectedId: string;
  onSelect: (id: string) => void;
  onConversationCreated?: () => void;
}

export const ConversationList = ({
  conversations,
  selectedId,
  onSelect,
  onConversationCreated,
}: ConversationListProps) => {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [partnerEmail, setPartnerEmail] = useState('');
  const [error, setError] = useState('');

  const handleCreateConversation = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!partnerEmail.trim()) {
      setError('Please enter partner email');
      return;
    }
    try {
      setError('');
      const response = await api.createConversation(partnerEmail);
      if (response.statusCode === 200) {
        setIsModalOpen(false);
        setPartnerEmail('');
        onConversationCreated?.();
      } else {
        setError('Failed to create conversation');
      }
    } catch (error) {
      console.error('Error creating conversation:', error);
      setError('Failed to create conversation');
    }
  };

  return (
    <div className="w-1/4 bg-white border-r border-gray-200">
      <div className="p-4 border-b border-gray-200">
        <div className="flex justify-between items-center">
          <h2 className="text-xl font-semibold text-gray-800">Conversations</h2>
          <button
            onClick={() => setIsModalOpen(true)}
            className="bg-blue-500 text-white p-2 rounded-full hover:bg-blue-600"
          >
            <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
              <path fillRule="evenodd" d="M10 3a1 1 0 011 1v5h5a1 1 0 110 2h-5v5a1 1 0 11-2 0v-5H4a1 1 0 110-2h5V4a1 1 0 011-1z" clipRule="evenodd" />
            </svg>
          </button>
        </div>
      </div>

      <div className="overflow-y-auto h-[calc(100vh-4rem)]">
        {conversations.map((conv) => (
          <div
            key={conv.id}
            onClick={() => onSelect(conv.id)}
            className={`p-4 cursor-pointer hover:bg-gray-50 ${
              selectedId === conv.id ? 'bg-blue-50' : ''
            }`}
          >
            <div className="flex justify-between items-start">
              <div className="flex flex-col">
                <h3 className="font-medium text-gray-900">{conv.name}</h3>
                <p className="text-sm text-gray-600 truncate">
                  {conv.lastMessage}
                </p>
              </div>
              {conv.unreadCount > 0 && (
                <span className="bg-blue-500 text-white text-xs px-2 py-1 rounded-full">
                  {conv.unreadCount}
                </span>
              )}
            </div>
            <p className="text-xs text-gray-500 mt-1">
              {new Date(conv.lastMessageAt).toLocaleDateString()}
            </p>
          </div>
        ))}
      </div>

      {isModalOpen && (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center">
          <div className="bg-white p-6 rounded-lg w-96">
            <h3 className="text-lg font-semibold mb-4">Create New Conversation</h3>
            <form onSubmit={handleCreateConversation}>
              {error && (
                <div className="text-red-500 text-sm mb-2">{error}</div>
              )}
              <input
                type="email"
                value={partnerEmail}
                onChange={(e) => setPartnerEmail(e.target.value)}
                placeholder="Enter partner email"
                className="w-full p-2 border border-gray-300 rounded mb-4"
                required
              />
              <div className="flex justify-end gap-2">
                <button
                  type="button"
                  onClick={() => {
                    setIsModalOpen(false);
                    setError('');
                    setPartnerEmail('');
                  }}
                  className="px-4 py-2 text-gray-600 hover:text-gray-800"
                >
                  Cancel
                </button>
                <button
                  type="submit"
                  className="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
                >
                  Create
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
}; 