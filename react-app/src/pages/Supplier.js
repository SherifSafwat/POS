import React, {useState, useEffect, useReducer, useContext  } from 'react';
import { dataReducer } from '../reducers/dataReducer';

export default function Supplier() {
    const [hi, setHi] = useState(["d1"]);
    const [toto, dispatch] = useReducer(dataReducer, [[]]);

    useEffect(() => {
        //setHi( h => h + 'hi2');
        //setHi(...hi, ["g2"]);
        //setHi(...hi, dispatch({ type: 'GET_SUPPLIERS'}) );
        dispatch({ type: 'GET_SUPPLIERS'});
      },[]);

    return (
        <div>{hi} * {toto} </div>
    )
}


