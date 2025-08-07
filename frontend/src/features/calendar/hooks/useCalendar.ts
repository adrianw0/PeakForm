import { useEffect, useState } from 'react';
import { MealDto } from '../../../types/dto';
import api from '../../../services/api';

const useCalendar = (date: string) => {
  const [meals, setMeals] = useState<MealDto[]>([]);

  useEffect(() => {
    api.get<MealDto[]>(`/meals?date=${date}`)
      .then(setMeals)
      .catch(() => setMeals([]));
  }, [date]);

  const addMeal = async (meal: MealDto) => {
    await api.post('/meals', meal);
    setMeals(prev => [...prev, meal]);
  };

  return { meals, addMeal };
};

export default useCalendar;
