import React, { useEffect } from 'react'
import { useParams } from 'react-router'
import LoadingSpinner from '../Component/UI/LoadingSpinner'
import useHttp from '../hooks/use-http'

const ProductPage = () => {

    const params = useParams();

    const{ prodId } = params;

/*     const { sendRequest, status, data: loadedProduct, error} = useHttp(
        getSingleProduct,
        true
    ); */

 /*    useEffect(() => {
        sendRequest(prodId);
        
    }, [sendRequest, prodId])

    if ( status == 'pending' ){
        return(
            <div>
                <LoadingSpinner />
            </div>
        )
    }

    if(error){
        return <div>{error}</div>
    } */

/*     if(!loadedProduct.text){
        return <p> Prodotto non trovato </p>
    } */

    return (
        <div>
            Pagina prodotto {prodId}
        </div>
    )
}

export default ProductPage
