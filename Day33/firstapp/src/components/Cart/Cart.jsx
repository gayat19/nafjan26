import { useState,useEffect } from "react";
import { useParams } from "react-router-dom";

export default function Cart(){
    const { id } = useParams();
    const [cart,setCart] = useState([]);
    useEffect(()=>{
        setCart([...cart,id]);
    },[id]);
    return(<>
    <h1>Cart Component</h1>
    {
        cart.length==0?
        "Cart is empty"
        :
        cart.map((item,index)=><div key={index}>{item}</div>)   
    }
    </>)
}