import { useState } from "react";

export function First(){
//    var name = "Ramu";
   const [name,setName] = useState("Ramu");
    const handleClick=()=>{
        alert("Button Clicked");
        console.log(`Before change - ${name} `);
        setName("Somu");
        console.log(`After change - ${name}`);
    }
    return(<>
    <h1>First Component - {name}</h1>
    <button onClick={handleClick} >Click Me</button>
    </>)
}