import React, { Component } from 'react'
import { Link } from 'react-router-dom';

class Navigation extends Component {
    render() {
        return (
            <nav class="stroke">
                <ul>
                    <li><Link to="/">Inicio</Link></li>
                    <li><Link to="/crearpedido">Pedidos</Link></li>
                </ul>
            </nav>
            
        )
    }
}


export default Navigation;