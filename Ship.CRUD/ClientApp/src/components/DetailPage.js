import React from 'react';
import {useNavigate, useParams} from 'react-router-dom';
import FormBody from './FormBody';

const DetailPage = () => {
  const [data, setData] = React.useState({});
  const params = useParams();
  const navigate = useNavigate();

  React.useEffect(() => {
    (async () => {
      const response = await fetch(`/ship/${params.id}`);
      if (!response.ok){
        console.log(response.statusText);
        return;
      }
      setData(await response.json());
    })()
  }, [params.id])

  const handleChange = (event) => {
    setData({
      ...data,
      [event.target.id]: event.target.value,
    });
  };

  const handleUpdate = () => {
    const request = {
      name: data.name,
      length: data.length,
      width: data.width,
      code: data.code
    };

    fetch(`/ship/${params.id}`, 
    {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(request)
    }).then((response) => {
      if (!response.ok){
        alert("Error creating a new ship");
        throw new Error(response.statusText);
      }
      alert("Successfully updated");
    });
    navigate('/');
  }

  const handleDelete = () => {
    fetch(`/ship/${params.id}`, 
    {
      method: 'DELETE',
      headers: { 'Content-Type': 'application/json' }
    }).then((response) => {
      if (!response.ok){
        alert("Error creating a new ship");
        throw new Error(response.statusText);
      }
      alert("Successfully deleted");
    });
    navigate('/');
  }

 return(
  <form className="d-flex flex-column">
    <FormBody onChange={handleChange} data={data}/>
    <div>
    <button value="Update" onClick={handleUpdate} style={{ width: '100px' , marginRight: '10px'}}>Update</button>
    <button value="Delete" onClick={handleDelete} style={{ width: '100px'}}>Delete</button>
    </div>
</form>
 )
}

export default DetailPage;

