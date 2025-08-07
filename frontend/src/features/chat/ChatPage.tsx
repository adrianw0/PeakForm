import { useState } from 'react';
import { useChat } from './hooks/useChat';

const ChatPage: React.FC = () => {
  const { messages, send } = useChat();
  const [prompt, setPrompt] = useState('');

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!prompt.trim()) return;
    send(prompt);
    setPrompt('');
  };

  return (
    <div>
      <div>
        {messages.map((m, idx) => (
          <div key={idx} style={{ textAlign: m.sender === 'user' ? 'right' : 'left' }}>
            <strong>{m.sender === 'user' ? 'You' : 'Assistant'}:</strong> {m.content}
          </div>
        ))}
      </div>
      <form onSubmit={handleSubmit}>
        <input value={prompt} onChange={(e) => setPrompt(e.target.value)} />
        <button type="submit">Send</button>
      </form>
    </div>
  );
};

export default ChatPage;
