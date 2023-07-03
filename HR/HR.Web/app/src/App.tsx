import { useForm } from 'react-hook-form';
import FormTextField from './components/forms/FormTextField';
import { useState } from 'react';
import React from 'react';

interface Information {
  name:string;
}

function App() {
  const { register, handleSubmit, formState: { errors } } = useForm<Information>();
  const [ information, setInformation ] = useState({} as Information);

  const onSubmit = (data:Information) => {
    console.log(data);
    console.log(errors);
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <FormTextField label="Name" name="name"register={register("name", { required: "Tanga mo" })} error={errors.name} />
      <button type="submit">Submit</button>
    </form>
  );
}

export default App;
