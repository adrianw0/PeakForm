import { useEffect, useState } from 'react';
import { UserDataDto } from '../../../types/dto';
import api from '../../../services/api';

const useProgress = () => {
  const [data, setData] = useState<UserDataDto | null>(null);

  useEffect(() => {
    api.get<UserDataDto>('/user-data')
      .then(setData)
      .catch(() => setData(null));
  }, []);

  const save = async (dto: UserDataDto) => {
    await api.post('/user-data', dto);
    setData(dto);
  };

  return { data, save };
};

export default useProgress;
