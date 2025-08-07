import { useEffect, useRef, useState } from 'react';
import { HubConnection } from '@microsoft/signalr';
import { buildChatConnection, sendPrompt, subscribeToMessages } from '../../../services/chat';
import { ChatMessage } from '../../../types/dto';

export function useChat() {
  const [connection, setConnection] = useState<HubConnection | null>(null);
  const [messages, setMessages] = useState<ChatMessage[]>([]);
  const assistantBuffer = useRef('');

  useEffect(() => {
    const conn = buildChatConnection();
    setConnection(conn);

    conn.start().then(() => {
      subscribeToMessages(conn, (chunk) => {
        assistantBuffer.current += chunk;
        setMessages((prev) => {
          const updated = [...prev];
          const last = updated[updated.length - 1];
          if (last && last.sender === 'assistant') {
            last.content = assistantBuffer.current;
          } else {
            updated.push({ sender: 'assistant', content: assistantBuffer.current });
          }
          return updated;
        });
      });
    });

    return () => {
      conn.stop();
    };
  }, []);

  const send = async (prompt: string) => {
    if (!connection) return;
    assistantBuffer.current = '';
    setMessages((prev) => [...prev, { sender: 'user', content: prompt }, { sender: 'assistant', content: '' }]);
    await sendPrompt(connection, prompt);
  };

  return { messages, send };
}
