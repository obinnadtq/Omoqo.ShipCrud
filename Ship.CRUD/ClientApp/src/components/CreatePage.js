import React from 'react';
import FormBody from './FormBody';

const CreatePage = () => {
  const [form, setForm] = React.useState({
    name : "",
    length: "",
    width: "",
    code: ""
  });

  const handleChange = (event) => {
    setForm({
      ...form,
      [event.target.id]: event.target.value,
    });
  };

  const handleSubmit = (event) => {
    const request = {
      name: form.name,
      length: form.length,
      width: form.width,
      code: form.code
    };

    fetch('/ship', 
    {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(request)
    }).then((response) => {
      if (!response.ok){
        alert("Error creating a new ship");
        throw new Error(response.statusText);
      }

      alert("Ship Created successfully");
      return response.json();
    });
    event.preventDefault();
    setForm({
      name : "",
      length: "",
      width: "",
      code: ""
    });
  }

  return (
    <form className="d-flex flex-column" onSubmit={handleSubmit}>
      <FormBody onChange={handleChange} data={form}/>
      <input type="submit" value="Create"  style={{ width: '100px'}}/>
    </form>
  );
}

export default CreatePage;
