const API_BASE = '/api';

async function request<T>(url: string, options: RequestInit = {}): Promise<T> {
  const res = await fetch(API_BASE + url, {
    headers: { 'Content-Type': 'application/json' },
    ...options,
  });
  if (!res.ok) throw new Error(await res.text());
  return res.json();
}

const api = {
  get: <T,>(url: string) => request<T>(url),
  post: <T,>(url: string, body: any) =>
    request<T>(url, { method: 'POST', body: JSON.stringify(body) }),
  del: <T,>(url: string) => request<T>(url, { method: 'DELETE' }),
};

export default api;
