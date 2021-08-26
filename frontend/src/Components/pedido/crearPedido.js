import React, { Component } from "react";
import { Link } from "react-router-dom";
import Navigation from "../Navigation";
import Radio from "@material-ui/core/Radio";
import RadioGroup from "@material-ui/core/RadioGroup";
import Table from "@material-ui/core/Table";
import Button from "@material-ui/core/Button";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import DeleteIcon from "@material-ui/icons/Delete";
import IconButton from "@material-ui/core/IconButton";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import FormControl from "@material-ui/core/FormControl";
import TextField from "@material-ui/core/TextField";
import axios from "axios";
import swal from "sweetalert";
import CircularProgress from '@material-ui/core/CircularProgress';


import { baseUrl } from "../../Constants/api_url";
import parseISOWithOptions from "date-fns/esm/fp/parseISOWithOptions";


const ApiCliente = baseUrl + "cliente/list";
const ApiProducto = baseUrl + "producto/list";
const Api = baseUrl + "pedido/crearpedido";

class crearPedido extends Component {
    onClickDelete() {
        
      
            this.state.clienteRadio = null;
            this.forceUpdate();
        
    }

    onClickDeleteProducto(id) {
        var i = this.state.productosSeleccionados.indexOf(id);

        if (i !== -1) {
            this.state.productosSeleccionados.splice(i, 1);
            this.forceUpdate();
        }
    }
    handleChangeCliente(value) {
        this.setState({ clienteRadio: value });
        console.log(value);
    }
    handleChangeClienteButton() {
        this.setState({ clienteSeleccionado:    this.state.clientes.filter((cliente) =>
            cliente.idCliente.toString().startsWith(
                this.state.clienteRadio)) });
     
    }

    handleChangeProducto(value) {
        this.setState({ productoRadio: value });
    }

    handleChangeProductoButton() {
        console.log(this.state.productoRadio)
        if (this.state.productoRadio == null) {
            swal("Error!", "No se ha agregado ningun Producto.", "error");
        } else {

            if (
                
                this.state.productosSeleccionados.includes(
                    this.state.productos.filter((producto) =>
                        producto.idProducto.toString().startsWith(
                            this.state.productoRadio,
                        )
                    )[0]
                )
            ) {
                swal("Error!", "El Producto ya se encuentra agregado.", "error");
            } else {
                
                    this.state.productosSeleccionados.push(
                        
                           
                            this.state.productos.filter((producto) =>
                            producto.idProducto.toString().startsWith(
                                this.state.productoRadio,
                            )
                        )[0]
                        
                    )
                    this.forceUpdate();
                
            }
        }
    }

    constructor(props) {
        super(props);

        this.state = {
            isLoaded: false,
            clientes: [],
            productos: [],
            productosSeleccionados:[],
            clienteSeleccionado : null,
            clienteRadio: null,
            productoRadio: null,    
            buscarCliente: null,  
            buscarProducto: null,  
            nuevoPedido: [
                
            ]    
        };
        this.updateInputBuscarCliente = this.updateInputBuscarCliente.bind(this);
        this.updateInputBuscarProducto = this.updateInputBuscarProducto.bind(
            this
        );
    }

    componentDidMount() {
        fetch(ApiCliente)
            .then((res) => res.json())
            .then((json) => {
                this.setState({
                    clientes: json,
                });
            });

        fetch(ApiProducto)
            .then((res) => res.json())
            .then((json) => {
                this.setState({
                    productos: json,
                    isLoaded: true,
                });
            });

    }

    render() {
        
   
        const {

           isLoaded,
            clientes,
            productos,
            productosSeleccionados,
            clienteRadio,
            productoRadio,  
            buscarCliente,  
            buscarProducto, 
            nuevoPedido,
            clienteSeleccionado
        } = this.state;

     
            nuevoPedido.idCliente = 1
      


        if (!isLoaded) {
            return <div><CircularProgress size={80} /></div>
          } else {
        return (    
              
            <div>
                <Navigation />
                <div>
                    <h1>Creacion de Pedido</h1>
                    <h3>Elija el Cliente:</h3>
                    <form class="formCliente">
                        <TextField
                            name="buscarCliente"
                            label="Buscar Cliente"
                            defaultValue={this.state.buscarCliente}
                            margin="normal"
                            variant="outlined"
                            onChange={this.updateInputBuscarCliente}
                            style={{ marginLeft: 20 }}
                        />
                        <br />
                        <FormControl
                            variant="outlined"
                            style={{ marginLeft: 10, marginTop: 16 }}
                        >
                            <RadioGroup
                                aria-label="Cliente"
                                name="cliente"
                                onChange={(event) =>
                                    this.handleChangeCliente(event.target.value)
                                }
                            >
                                {clientes
                                    .filter((cliente) =>
                                        cliente.idCliente.toString().startsWith(buscarCliente)
                                    )
                                    .map((cliente) => (
                                        <FormControlLabel
                                            value={cliente.idCliente}
                                            control={<Radio />}
                                            label={
                                                cliente.idCliente +
                                                " - " +
                                                cliente.nombre +
                                                " " +
                                                cliente.apellido
                                            }
                                        />
                                    ))}
                            </RadioGroup>
                            <Button
                                variant="contained"
                                color="primary"
                                style={{ margin: 20 }}
                                onClick={(event) =>
                                    this.handleChangeClienteButton(event.target.value)
                                }
                            >
                                Agregar Cliente
              </Button>
                        </FormControl>

                        <TableContainer>
                            <Table aria-label="simple table">
                                <TableHead>
                                    <TableRow>
                                        <TableCell>
                                            <strong>Id Cliente</strong>
                                        </TableCell>
                                        <TableCell>
                                            <strong>Nombre</strong>
                                        </TableCell>
                                        <TableCell>
                                            <strong>Apellido</strong>
                                        </TableCell>
                                        <TableCell>
                                            <strong></strong>
                                        </TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {console.log(clienteSeleccionado)}
                                {clienteSeleccionado ? (
                                clienteSeleccionado.map((item) => (
                                
                                <TableRow key={item.idCliente}>
                                <TableCell component="th" scope="row">
                                    {item.idCliente}
                                </TableCell>
                                <TableCell component="th" scope="row">
                                    {item.nombre}
                                </TableCell>
                                <TableCell component="th" scope="row">
                                    {item.apellido}
                                </TableCell>
                                <IconButton
                                    aria-label="Delete"
                                    onClick={() => this.onClickDelete()}
                                >
                                    <DeleteIcon />
                                </IconButton>
                            </TableRow>       
                            ))
                                ) : (
                                   <h1></h1>
                                    )}
                                 
                                </TableBody>
                            </Table>
                        </TableContainer>
                        <br />
                        <br />
                        <h3>Elija el/los Productos(s):</h3>
                        <TextField
                            name="buscarProductos"
                            label="Buscar Productos"
                            defaultValue={this.state.buscarProducto}
                            margin="normal"
                            variant="outlined"
                            onChange={this.updateInputBuscarProducto}
                            style={{ marginLeft: 20 }}
                        />
                        <br />
                        <FormControl
                            variant="outlined"
                            style={{ marginLeft: 10, marginTop: 16 }}
                        >
                            <RadioGroup
                                aria-label="Producto"
                                name="producto"
                                onChange={(event) =>
                                    this.handleChangeProducto(event.target.value)
                                }
                            >
                                {productos
                                    .filter((producto) =>
                                        producto.idProducto.toString().startsWith(
                                            buscarProducto
                                        )
                                    )
                                    .map((producto) => (
                                        <FormControlLabel
                                            value={producto.idProducto}
                                            control={<Radio />}
                                            label={
                                                producto.idProducto +
                                                " - " +
                                                producto.nombre 
                                               
                                            }
                                        />
                                    ))}
                            </RadioGroup>
                            <Button
                                variant="contained"
                                color="primary"
                                style={{ margin: 20 }}
                                onClick={(event) =>
                                    this.handleChangeProductoButton(event.target.value)
                                }
                            >
                                Agregar Producto
              </Button>
                        </FormControl>
                        <TableContainer>
                            <Table aria-label="simple table">
                                <TableHead>
                                    <TableRow>
                                        <TableCell>
                                            <strong>Id</strong>
                                        </TableCell>
                                        <TableCell>
                                            <strong>Nombre</strong>
                                        </TableCell>
                                        <TableCell>
                                            <strong></strong>
                                        </TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {console.log(productosSeleccionados)}
                                    {productosSeleccionados.map((item) => (
                                        <TableRow key={item.idProducto}>
                                            <TableCell component="th" scope="row">
                                                {item.idProducto}
                                            </TableCell>
                                            <TableCell component="th" scope="row">
                                                {item.nombre}
                                            </TableCell>
                                            <IconButton
                                                aria-label="Delete"
                                                onClick={() => this.onClickDeleteProducto(item)}
                                            >
                                                <DeleteIcon />
                                            </IconButton>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>

                        <div style={{ marginTop: 20 }}>
                            <Button
                                variant="contained"
                                color="primary"
                                style={{ marginTop: 1, margin: 10 }}
                                onClick={() =>
                                    PostApi(
                                        nuevoPedido
                                    )
                                }
                            >
                                Guardar
                </Button>
                            <Link to="/cuentas">
                                <Button
                                    variant="contained"
                                    color="secondary"
                                    style={{ marginLeft: 10 }}
                                >
                                    Cancelar
                </Button>
                            </Link>
                        </div>
                    </form>
                </div>
            </div>
        );
  }
    }
    updateInputBuscarCliente(event) {
        if (event.target.value === "") {
            this.setState({ buscarCliente: null });
            this.forceUpdate();
        } else if (event.target.value === " ") {
            this.setState({ buscarCliente: "" });
            this.forceUpdate();
        } else {
            this.setState({ buscarCliente: event.target.value });
        }
    }

    updateInputBuscarProducto(event) {
        if (event.target.value === "") {
            this.setState({ buscarProducto: null });
            this.forceUpdate();
        } else if (event.target.value === " ") {
            this.setState({ buscarProducto: "" });
            this.forceUpdate();
        } else {
            this.setState({ buscarProducto: event.target.value });
        }
    }
}

const PostApi = (
    nuevoPedido
) =>
    axios
        .post(Api, nuevoPedido)
        .then((response) => {

            swal("Exito!", "Pedido Creado!", "success");
        })
        .catch((error) => {

            swal("Error!", error.response.data, "error");
        });


export default crearPedido;
