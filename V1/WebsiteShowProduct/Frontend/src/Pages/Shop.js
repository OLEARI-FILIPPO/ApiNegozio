import React, { useState, Component } from 'react'
import '../Styles/Shop.css'

import  { Link, Route, Routes } from 'react-router-dom'

import Button from '@material-tailwind/react/Button';
import Heading3 from '@material-tailwind/react/Heading3'
import Card from "@material-tailwind/react/Card";
import CardBody from "@material-tailwind/react/CardBody";
import CardFooter from "@material-tailwind/react/CardFooter";
import Paragraph from "@material-tailwind/react/Paragraph";

import "@material-tailwind/react/tailwind.css";


export default class Shop extends Component {

  constructor(props){
    super(props);

    this.state = { 
      error: null,
      isLoaded: false,
      items: []
    };
  }

  componentDidMount() {
    fetch("http://localhost:44362/api/prodotti")
      .then(res => res.json())
      .then(
        (result) => {
          this.setState({
            isLoaded: true,
            items: result
          });
          console.log(result)
        },
        // Nota: è importante gestire gli errori qui
        // invece di un blocco catch() in modo da non fare passare
        // eccezioni da bug reali nei componenti.
        (error) => {
          this.setState({
            isLoaded: true,
            error
          });
        }
        
      )
      
  }

  render() {

    const { error, isLoaded, items } = this.state;
    if (error) {
      return <div>Error: {error.message}</div>;
    } else if (!isLoaded) {
      return <div>Loading...</div>;
    } else {
    return (
      <div className="shop">

        <div className="mb-10 py-2  text-center">
          <div className="flex flex-wrap justify-center">
              <div className="w-full lg:w-8/12 px-4 flex flex-col items-center">
                  <Heading3 color="black">
                      SHOP DI  PAOLA B. Curvy
                  </Heading3>
              </div>
          </div>
        </div>

        <div className="card-container">


          { 
            items != null ? 
              items.map( product => (
              <Card className="mb-10" key={product.idPrdt}>
                <img className="product-image" src={product.imgUrl} />

                <CardBody>
                  <h2 color="gray">{product.nome}</h2>
                  <Paragraph color="gray">
                    {/* Image alt */}
                    {product.descrizione}
                  </Paragraph>
                </CardBody>

                <CardFooter>


                  <Link to={`/shop:${product.idPrdt}`}>
                    <Button color="purple" size="lg" ripple="dark">
                      Dettagli
                    </Button>
                  </Link>


                  <label>{product.prezzo}</label>

                </CardFooter>
              </Card> )) : <h1> errore</h1> 
            
          }
              
          
        </div>
      </div>
    )
  }
}
}