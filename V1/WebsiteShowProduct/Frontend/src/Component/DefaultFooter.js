import H5 from '@material-tailwind/react/Heading5';
import LeadText from '@material-tailwind/react/LeadText';
import Icon from '@material-tailwind/react/Icon';
import "@material-tailwind/react/tailwind.css";

import { Link } from 'react-router-dom';

import Navigation from './Navigation';

export default function DefaultFooter() {
    return (
        <div className="footer z-auto">
            <footer className="relative bg-white pt-6 pb-6">
                <div className="container max-w-6xl mx-auto px-4">
                    <div className="flex flex-wrap text-center lg:text-left pt-6">
                        <div className="w-full lg:w-4/12 px-4">
                            
                            <H5 color="gray">PAOLA B. Curvy</H5>
                            <div className="-mt-4">
                                <LeadText color="blueGray">
                                    Visita i nostri social e rimani aggiornato
                                </LeadText>
                            </div>
                            <div className="flex gap-4 mt-6 md:justify-start md:mb-6 mb-8 justify-center">
                                
                                <a
                                    href="https://www.facebook.com/paolabcurvy2/"
                                    className="grid place-items-center bg-purple-600 text-blue-600 shadow-md font-normal h-10 w-10 items-center justify-center align-center rounded-full outline-none focus:outline-none"
                                    target="_blank"
                                    rel="noopener noreferrer"
                                >
                                    <Icon
                                        family="font-awesome"
                                        name="fab fa-instagram"
                                        color="purple"
                                    />
                                </a>
                                <a
                                    href="https://www.instagram.com/paolabcurvy/"
                                    className="grid place-items-center bg-white text-indigo-500 shadow-md font-normal h-10 w-10 items-center justify-center align-center rounded-full outline-none focus:outline-none"
                                    target="_blank"
                                    rel="noopener noreferrer"
                                >
                                    <Icon
                                        family="font-awesome"
                                        name="fab fa-instagram"
                                        color="purple"
                                    />
                                </a>
                            </div>
                            </div>
                            <div className="w-full lg:w-4/12 px-4">
                                <div className="flex flex-wrap items-top">
                                    <div className="w-full px-4 md:mb-0 mb-8">
                                        <h3>Vieni a trovarci</h3><br></br>
                                        <div className="-mt-4">
                                            <ul className="list-unstyled">
                                                <li>
                                                    <a
                                                        href=""
                                                        target=""
                                                        rel="noreferrer"
                                                        className="text-gray-700 hover:text-gray-900 block pb-2 text-sm"
                                                    >
                                                        Via Trento, 6/A, 42048 Rubiera RE
                                                    </a>
                                                </li>
                                                <li>
                                                    <a
                                                        href=""
                                                        target=""
                                                        rel="noreferrer"
                                                        className="text-gray-700 hover:text-gray-900 block pb-2 text-sm"
                                                    >
                                                        353 432 9879
                                                    </a>
                                                </li>

                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        
                        <div className="w-full lg:w-4/12 px-4">
                            <div className="flex flex-wrap items-top">
                                <div className="w-full  px-4 ml-auto md:mb-0 mb-8">
                                    <span className="block uppercase text-gray-900 text-sm font-serif font-medium mb-2">
                                        Link utili
                                    </span>
                                    <ul className="list-unstyled">
                                        <li>
                                            <Link
                                                to="/contatti"
                                                className="text-gray-700 hover:text-gray-900 block pb-2 text-sm"
                                                onClick={()=>{}}
                                            >
                                                Contatti
                                            </Link>
                                        </li>
                                        <li>
                                            <Link
                                                to="/shop"
                                                className="text-gray-700 hover:text-gray-900 block pb-2 text-sm"
                                            >
                                                Shop
                                            </Link>
                                        </li>
                                        <li>
                                            <Link
                                                to="/home"
                                                className="text-gray-700 hover:text-gray-900 block pb-2 text-sm"
                                            >
                                                Home
                                            </Link>
                                        </li>
                                        <li>
                                            <Link
                                                to="/news"
                                                className="text-gray-700 hover:text-gray-900 block pb-2 text-sm"
                                            >
                                                News
                                            </Link>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr className="my-6 border-gray-500" />
                    <div className="flex flex-wrap items-center md:justify-between justify-center">
                        <div className="w-full md:w-4/12 px-4 mx-auto text-center">
                            <div className="text-sm text-gray-700 font-medium py-1">
                                Copyright © {new Date().getFullYear()} Paola B. Curvy .
                            </div>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
    );
}
