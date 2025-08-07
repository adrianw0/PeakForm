import React, { useState, useEffect } from 'react';
import useProgress from './hooks/useProgress';

const ProgressPage: React.FC = () => {
  const { data, save } = useProgress();
  const [weight, setWeight] = useState<number>(data?.weight ?? 0);

  useEffect(() => {
    if (data) setWeight(data.weight);
  }, [data]);

  return (
    <div>
      <h2>Progress</h2>
      <div className="mb-3">
        <label className="form-label">Weight (kg)</label>
        <input
          type="number"
          className="form-control"
          value={weight}
          onChange={e => setWeight(parseFloat(e.target.value))}
        />
      </div>
      <button className="btn btn-primary" onClick={() => save({ ...data, weight } as any)}>
        Save
      </button>
    </div>
  );
};

export default ProgressPage;
