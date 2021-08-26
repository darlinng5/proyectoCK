import React from 'react';
import './App.css';
import { Route } from 'react-router-dom';
import Home from './Home';
import Navigation from './Components/Navigation';
import crearPedido from './Components/pedido/crearPedido';


function App() {
  // class movimientoCuentas extends Component  

  return (
    <div className="App" >
      <switch>
        <Route exact path='/navigation' component={Navigation} />
        <Route exact path='/' component={Home} />     
        <Route exact path='/crearpedido' component={crearPedido} />
      </switch>
    </div>
  )
}

export default App;