import React from 'react';
import { Routes, Route, Navigate } from 'react-router-dom';
import Navbar from './components/Navbar';
import CalendarPage from './features/calendar/CalendarPage';
import FoodList from './features/food/FoodList';
import ProgressPage from './features/progress/ProgressPage';

const App: React.FC = () => {
  return (
    <>
      <Navbar />
      <div className="container mt-3">
        <Routes>
          <Route path="/" element={<Navigate to="/calendar" replace />} />
          <Route path="/calendar" element={<CalendarPage />} />
          <Route path="/food" element={<FoodList />} />
          <Route path="/progress" element={<ProgressPage />} />
        </Routes>
      </div>
    </>
  );
};

export default App;
