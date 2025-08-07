import React, { useState } from 'react';
import useCalendar from './hooks/useCalendar';

const CalendarPage: React.FC = () => {
  const today = new Date().toISOString().split('T')[0];
  const [date, setDate] = useState<string>(today);
  const { meals, addMeal } = useCalendar(date);

  return (
    <div>
      <h2>Daily Meals</h2>
      <input
        type="date"
        className="form-control mb-3"
        value={date}
        onChange={e => setDate(e.target.value)}
      />
      <ul className="list-group mb-3">
        {meals.map(m => (
          <li key={m.id} className="list-group-item">
            {m.foodItems.length} items
          </li>
        ))}
      </ul>
      <button
        className="btn btn-primary"
        onClick={() => addMeal({ id: crypto.randomUUID(), date, foodItems: [] })}
      >
        Add Meal
      </button>
    </div>
  );
};

export default CalendarPage;
