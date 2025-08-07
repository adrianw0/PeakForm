import React, { useState } from 'react';
import useFoods from './hooks/useFoods';
import FoodForm from './FoodForm';

const FoodList: React.FC = () => {
  const { products, addProduct, deleteProduct } = useFoods();
  const [showForm, setShowForm] = useState(false);

  return (
    <div>
      <h2>Products</h2>
      <button className="btn btn-primary mb-3" onClick={() => setShowForm(true)}>
        Add Product
      </button>
      {showForm && (
        <FoodForm
          onSubmit={p => { addProduct(p); setShowForm(false); }}
          onCancel={() => setShowForm(false)}
        />
      )}
      <ul className="list-group">
        {products.map(p => (
          <li key={p.id} className="list-group-item d-flex justify-content-between">
            <span>{p.name}</span>
            <button className="btn btn-sm btn-danger" onClick={() => deleteProduct(p.id)}>
              Delete
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default FoodList;
