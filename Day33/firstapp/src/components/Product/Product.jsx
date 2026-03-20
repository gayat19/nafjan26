const Product =(props)=>{
    const onBuyClick=()=>{
        props.onBuyNow(props.prod.id);
    }
    return(<>
    <div>
        <h2>{props.prod.title}</h2>
        <img height="200" width="200" src={props.prod.image}/>
        <div>{props.prod.description}</div>
        <button onClick={onBuyClick}>Buy Now</button>
    </div>
    </>);

}

export default Product;