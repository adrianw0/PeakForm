import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

export function buildChatConnection(): HubConnection {
  return new HubConnectionBuilder().withUrl('/chatHub').withAutomaticReconnect().build();
}

export async function sendPrompt(connection: HubConnection, prompt: string): Promise<void> {
  await connection.invoke('SendPrompt', prompt);
}

export function subscribeToMessages(connection: HubConnection, handler: (message: string) => void): void {
  connection.on('ReceiveMessage', (_user: string, message: string) => handler(message));
}
