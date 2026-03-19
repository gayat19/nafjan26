import { useEffect,useState } from "react"

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

    const updateProducts=()=>{
        console.log("Before update - ",products);
        setProducts([...products,"Test1"]);
        console.log("After update - ",products);
    }
    return(<>
    <h1>Products Component</h1>
    {
        products?
        products.map((product)=><p key={product.id}>{product.title}</p>)
        :
        "Loading..."    
    }
  
    </>)
}
