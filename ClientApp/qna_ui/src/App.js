
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import QuesBank from "./QuesBank";
import { useState, useEffect } from 'react';
import AddQues from './AddQues';

function App() {
  const [isExpanded, setExpanded] = useState(false);
  const handleExpandClick = () => {
      setExpanded(!isExpanded);
  };

  const [data, setData] = useState([]);
  useEffect(() => {
      fetch('https://localhost:7145/api/QNAs', {
        method: 'GET',
      })
        .then((response) => response.json())
        .then((responseData) => {
          setData(responseData)
        })
        .catch( (error) => {
          console.error("Unable to get the data from backend. Because, ", error);
        }          
        )
    }, []
  );

  return (
    <>
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <a className="navbar-brand" href="#">Interview Question-Answer Bank</a>
        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className="collapse navbar-collapse" id="navbarSupportedContent">
          <ul className="navbar-nav mr-auto">
            <li className="nav-item active">
              <button className="nav-link" href="#">Dashboard</button>
            </li>
            <li className="nav-item">
              <button className="nav-link" onClick={handleExpandClick}>Add Questions</button>
            </li>
          </ul>
        </div>
      </nav>
      <div className='addQues'>
        {isExpanded && (
          <AddQues/>
        )}
      </div>

      {console.log(data)}
      <div className='QuesCard'>
        {
          data.map((items) =>(
            <>
              <div className = "SingleCard">
                <QuesBank key={items.id} id={items.id} ques={items.question} ans={items.answer} comp={items.company} />
              </div>
            </>
          ))
        }        
      </div>
    </>
  );
}

export default App;
