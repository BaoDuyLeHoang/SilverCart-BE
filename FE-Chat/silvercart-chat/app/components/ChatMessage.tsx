import { Message } from '../types';

interface ChatMessageProps {
  message: Message;
  isOwnMessage: boolean;
}

export const ChatMessage = ({ message, isOwnMessage }: ChatMessageProps) => {
  const formatTime = (dateString: string | null) => {
    if (!dateString) return '';
    try {
      const date = new Date(dateString);
      return date.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
    } catch (error) {
      console.error('Error formatting date:', error);
      return '';
    }
  };

  return (
    <div
      className={`flex ${
        isOwnMessage ? 'justify-end' : 'justify-start'
      }`}
    >
      <div
        className={`max-w-[70%] rounded-lg p-3 ${
          isOwnMessage
            ? 'bg-blue-600 text-white'
            : 'bg-white text-gray-800 shadow-sm'
        }`}
      >
        <p className="text-base">{message.content}</p>
        <div className="flex items-center mt-1 space-x-2">
          <p className="text-xs opacity-70">
            {formatTime(message.creationDate)}
          </p>
          {message.isRead && isOwnMessage && (
            <span className="text-xs opacity-70">✓</span>
          )}
          {message.isModified && (
            <span className="text-xs opacity-70">(edited)</span>
          )}
        </div>
      </div>
    </div>
  );
}; 