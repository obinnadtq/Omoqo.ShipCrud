import React from 'react';

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

      return response.json();
    });
    
    alert("Ship Created successfully");
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
      <div style={{ marginBottom: '20px'}}>
        <label htmlFor="name" style={{ marginRight: '10px'}}>Name</label>
        <input id="name" type="text" value={form.name} name="name" style={{ width: '291px'}} onChange={handleChange} required />
      </div>
      <div style={{ marginBottom: '20px'}}>
        <label htmlFor="length" style={{ marginRight: '10px'}}>Length</label>
        <input id="length" type="number" value={form.length} name="length" style={{ width: '288px'}} onChange={handleChange} required/>
      </div>
      <div style={{ marginBottom: '20px'}}>
        <label htmlFor="width" style={{ marginRight: '10px'}}>Width</label>
        <input id="width" type="number" value={form.width} name="width" style={{ width: '293px'}} onChange={handleChange} required/>
      </div>
      <div style={{ marginBottom: '20px'}}>
        <label htmlFor="code" style={{ marginRight: '10px'}}>Code</label>
        <input id="code" type="text" type="string" value={form.code} name="code" style={{ width: '300px'}} onChange={handleChange} required/>
      </div>
      <input type="submit" value="Create"  style={{ width: '100px'}}/>
    </form>
  );
}

export default CreatePage;
