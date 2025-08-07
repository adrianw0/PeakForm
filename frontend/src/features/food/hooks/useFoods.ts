import { useEffect, useState } from 'react';
import { ProductDto } from '../../../types/dto';
import api from '../../../services/api';

const useFoods = () => {
  const [products, setProducts] = useState<ProductDto[]>([]);

  useEffect(() => {
    api.get<ProductDto[]>('/products')
      .then(setProducts)
      .catch(() => setProducts([]));
  }, []);

  const addProduct = async (product: ProductDto) => {
    await api.post('/products', product);
    setProducts(prev => [...prev, product]);
  };

  const deleteProduct = async (id: string) => {
    await api.del(`/products/${id}`);
    setProducts(prev => prev.filter(p => p.id !== id));
  };

  return { products, addProduct, deleteProduct };
};

export default useFoods;
