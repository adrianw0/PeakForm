export interface Nutrient {
  id: string;
  name: string;
  unit: string;
}

export interface NutrientValue {
  nutrient: Nutrient;
  value: number;
}

export interface ProductDto {
  id: string;
  name: string;
  ean: string;
  description: string;
  nutrients: NutrientValue[];
}

export interface Ingredient {
  product: ProductDto;
  weight: number;
  unit: string;
}

export interface DishDto {
  id: string;
  name: string;
  description: string;
  ingredients: Ingredient[];
}

export interface MealFoodItem {
  foodItem: ProductDto | DishDto;
  weight: number;
  weightUnit: string;
}

export interface MealDto {
  id: string;
  foodItems: MealFoodItem[];
  date: string;
}

export type Gender = 'Male' | 'Female';

export type ActivityLevel =
  | 'Sedentary'
  | 'Light'
  | 'Moderate'
  | 'Active'
  | 'VeryActive';

export interface UserDataDto {
  weight: number;
  height: number;
  age: number;
  gender?: Gender;
  bodyFatPercentage: number;
  muscleMassPercentage: number;
  activityLevel?: ActivityLevel;
  waistCircumference: number;
  hipCircumference: number;
  neckCircumference: number;
  goalBodyFatPercentage: number;
  goalWeight: number;
  goalMuscleMassPercentage: number;
  bmi: number;
  bmr: number;
}
