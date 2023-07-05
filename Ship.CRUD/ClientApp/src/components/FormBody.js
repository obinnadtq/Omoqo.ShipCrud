import React from 'react';

const FormBody = ({onChange, data}) => {
  return (
    <div>
      <div style={{ marginBottom: '20px'}}>
          <label htmlFor="name" style={{ marginRight: '10px'}}>Name</label>
          <input id="name" type="text" value={data.name} name="name" style={{ width: '291px'}} onChange={onChange} required />
      </div>
      <div style={{ marginBottom: '20px'}}>
          <label htmlFor="length" style={{ marginRight: '10px'}}>Length</label>
          <input id="length" type="number" value={data.length} name="length" style={{ width: '288px'}} onChange={onChange} required/>
      </div>
      <div style={{ marginBottom: '20px'}}>
          <label htmlFor="width" style={{ marginRight: '10px'}}>Width</label>
          <input id="width" type="number" value={data.width} name="width" style={{ width: '293px'}} onChange={onChange} required/>
      </div>
      <div style={{ marginBottom: '20px'}}>
          <label htmlFor="code" style={{ marginRight: '10px'}}>Code</label>
          <input id="code" type="text" type="string" value={data.code} name="code" style={{ width: '300px'}} onChange={onChange} required/>
      </div>
    </div>
      
  )
};

export default FormBody;