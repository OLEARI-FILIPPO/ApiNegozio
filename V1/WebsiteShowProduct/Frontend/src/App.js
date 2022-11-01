import { Route, Routes, Navigate, Router } from 'react-router-dom';
import DefaultFooter from './Component/DefaultFooter';

//Component
import Navbar from './Component/Navigation';

//Pages
import Home from './Pages/Home';
import NotFound from './Pages/NotFound';
import Shop from './Pages/Shop';
import ProductPage from './Pages/ProductPage';



function App() {
  return (
    <div >
      <>
      <Navbar select={Router}/>

      <Routes>
        
        <Route path='/' element={<Navigate replace to='/home' />}  />
        <Route path='/home' exact element={<Home />} />
        <Route path='/shop' element={<Shop />} />
        <Route path='/shop:prodId' element={<ProductPage />} />

        {/* Path non trovato */}
        <Route path='*' element={<NotFound />} />

      </Routes>

      <DefaultFooter />
    </>
    </div>
  );
}

export default App;
