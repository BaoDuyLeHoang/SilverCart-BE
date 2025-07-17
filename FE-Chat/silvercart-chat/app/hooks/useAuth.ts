import { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { api } from '../services/api';
import { User } from '../types';

export const useAuth = () => {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(true);
  const router = useRouter();

  useEffect(() => {
    checkAuth();
  }, []);

  const checkAuth = async () => {
    try {
      const userId = localStorage.getItem('userId');
      const role = localStorage.getItem('role');
      
      if (!userId || !role || userId === 'undefined' || role === 'undefined') {
        throw new Error('No user ID or role found');
      }
      const token = localStorage.getItem('accessToken');
      
      if (!token) {
        throw new Error('No token found');
      }
      
      setUser({
        id: userId,
        role: role,
      });
      
    } catch (error) {
      console.error('Auth error:', error);
      setUser(null);
      localStorage.clear();
      router.push('/login');
    } finally {
      setLoading(false);
    }
  };

  const login = async (email: string, password: string) => {
    try {
      const response = await api.login(email, password);
      console.log('Login successful:', response);
      
      localStorage.setItem('accessToken', response.data.accessToken);
      localStorage.setItem('userId', response.data.userId);
      localStorage.setItem('role', response.data.role);

      setUser({
        id: response.userId,
        role: response.role
      });

      console.log('Navigating to chat...');
      router.push('/chat');
    } catch (error) {
      console.error('Login error:', error);
      throw error;
    }
  };

  const logout = () => {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('userId');
    localStorage.removeItem('role');
    setUser(null);
    router.push('/login');
  };

  return {
    user,
    loading,
    login,
    logout,
    isAuthenticated: !!user,
  };
}; 