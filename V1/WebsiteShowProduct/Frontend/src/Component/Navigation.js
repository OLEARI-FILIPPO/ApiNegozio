import React, { useState } from "react";
import {Link} from 'react-router-dom'

import Navbar from "@material-tailwind/react/Navbar";
import NavbarContainer from "@material-tailwind/react/NavbarContainer";
import NavbarWrapper from "@material-tailwind/react/NavbarWrapper";
import Image from "@material-tailwind/react/Image";
import NavbarToggler from "@material-tailwind/react/NavbarToggler";
import NavbarCollapse from "@material-tailwind/react/NavbarCollapse";
import Nav from "@material-tailwind/react/Nav";
import NavItem from "@material-tailwind/react/NavItem";
import NavLink from "@material-tailwind/react/NavLink";

import '../Styles/Navbar.css'

import logo from '../Images/paolab_w.png'




export default function Navigation() {
  const [openNavbar, setOpenNavbar] = useState(false);
  const [active, setActive] = useState('home');

  return (
      
      <div className="navbar">
        <Navbar color="lightBlue" navbar>
            <NavbarContainer>
                <NavbarWrapper>
                    <Link to ="/home">
                            <Image
                                className="logo"
                                src={logo}
                                rounded={false}
                                raised={false}
                                alt="Paola B. Curvy"ì
                            />
                    </Link>
                    <NavbarToggler
                        color="white"
                        onClick={() => setOpenNavbar(!openNavbar)}
                        ripple="light"
                    />
                </NavbarWrapper>

                <NavbarCollapse open={openNavbar}>
                    <Nav className="toggle-navigation">
                        <Link to = "/home">
                            <NavItem active={`${active === 'home' ? "light":""}`} 
                                    onClick={()=>{setActive('home')}} 
                                    ripple="light"
                                    to='/home'>
                                        
                                    Home
                            
                            </NavItem>
                        </Link>
                        
                        <Link to = "/shop">
                            <NavItem active={`${active === 'shop' ? "light":""}`} 
                                onClick={()=>{setActive('shop')}} 
                                ripple="light">
                                    
                                Shop
                        
                            </NavItem>
                        </Link>
                        <Link to = "/news">
                            <NavItem active={`${active === 'news' ? "light":""}`} 
                                onClick={()=>{setActive('news')}} 
                                ripple="light">
                                    
                                News
                        
                            </NavItem>
                        </Link>
                        <Link to = "/contatti">
                            <NavItem active={`${active === 'contatti' ? "light":""}`} 
                                onClick={()=>{setActive('contatti')}} 
                                ripple="light">
                                    
                                Contatti
                        
                            </NavItem>
                        </Link>

                    </Nav>
                </NavbarCollapse>
            </NavbarContainer>
        </Navbar>
    </div>
  );
}