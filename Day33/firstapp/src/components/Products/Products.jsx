import { useEffect,useState } from "react"
import Product from "../Product/Product";

 export default function Products(){
    const [products,setProducts] = useState();
    console.log("Products Component Rendered");

    useEffect(()=>{
        console.log("Products Component Mounted");
        fetch("https://fakestoreapi.com/products")
        .then(res=>res.json())
        .then(data=>{
            setProducts(data);
        })
    },[]);
    const onBuyNowClick=(prod)=>{
        alert(`You have bought ${prod}`);
    }
    const updateProducts=()=>{
        console.log("Before update - ",products);
        setProducts([...products,"Test1"]);
        console.log("After update - ",products);
    }
    return(<>
    <h1>Products Component</h1>
    {
        products?
        products.map((product)=><Product onBuyNow={onBuyNowClick} key={product.id} prod={product}/>)
        :
        "Loading..."    
    }
  
    </>)
}
