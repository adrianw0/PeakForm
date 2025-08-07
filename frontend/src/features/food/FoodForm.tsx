import React, { useState } from 'react';
import { ProductDto } from '../../types/dto';

interface Props {
  onSubmit: (product: ProductDto) => void;
  onCancel: () => void;
}

const FoodForm: React.FC<Props> = ({ onSubmit, onCancel }) => {
  const [name, setName] = useState('');
  const [ean, setEan] = useState('');

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSubmit({ id: crypto.randomUUID(), name, ean, description: '', nutrients: [] });
  };

  return (
    <form onSubmit={handleSubmit} className="mb-3">
      <div className="mb-3">
        <label className="form-label">Name</label>
        <input className="form-control" value={name} onChange={e => setName(e.target.value)} required />
      </div>
      <div className="mb-3">
        <label className="form-label">EAN</label>
        <input className="form-control" value={ean} onChange={e => setEan(e.target.value)} />
      </div>
      <button type="submit" className="btn btn-success me-2">Save</button>
      <button type="button" className="btn btn-secondary" onClick={onCancel}>Cancel</button>
    </form>
  );
};

export default FoodForm;
