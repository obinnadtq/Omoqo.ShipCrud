import React from 'react';
import {useNavigate} from 'react-router-dom';

const Home = () => {
  const [data, setData] = React.useState();
  const [loading, setLoading] = React.useState(true);

  const navigate = useNavigate();

  React.useEffect(() => {
    (async () => {
      const response = await fetch('/ship');
      if (!response.ok){
        console.log(response.statusText);
        return;
      }
      setData(await response.json());
      setLoading(false);
    })()
  }, [data])

  const renderShipsTable = (ships) => {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Length</th>
            <th>Width</th>
            <th>Code</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {ships.map(ship =>
            <tr key={ship.id}>
              <td>{ship.name}</td>
              <td>{ship.length}</td>
              <td>{ship.width}</td>
              <td>{ship.code}</td>
              <td><button onClick={() => navigate(`/detail/${ship.id}`)}>Edit</button></td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  const contents = loading
  ? <p><em>Loading...</em></p>
  : renderShipsTable(data);

  return (
    <div>
      <div className="d-flex justify-content-between">
      <h1 id="tabelLabel">Ship List</h1>
      <button onClick={() => navigate('/create')}>Create New Ship</button>
      </div>
      <div>
        {contents}
      </div>
    </div>
  );
}

export default Home;
