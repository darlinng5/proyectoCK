import React from 'react';
import logo from './logo.svg';
import './App.css';
import 'semantic-ui-css/semantic.min.css'
import { Grid } from 'semantic-ui-react';
import { MenuPrincipal } from './components/MenuPrincipal/MenuPrincipal';
import { PanelPrincipal } from './components/PanelPrincipal/PanelPrincipal';

function App() {
  return (
    <React.Fragment>
      <Grid columns="equal" className = "app">
          <MenuPrincipal></MenuPrincipal>
        <Grid.Column style={{marginLeft:320}}>
            <PanelPrincipal></PanelPrincipal>
        </Grid.Column>

      </Grid>

    </React.Fragment>
  );
}

export default App;
