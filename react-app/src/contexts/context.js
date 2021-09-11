import React, { createContext, useReducer } from 'react';
import { dataReducer } from '../reducers/dataReducer';

export const gContext = createContext();

const gContextProvider = (props) => {
  
  /*const [data, dispatch] = useReducer(dataReducer, []); () => {
    const localData = localStorage.getItem('books');
    return localData ? JSON.parse(localData) : [];
  });*/

  return (
    
    <gContext.Provider >
      {props.children}
    </gContext.Provider>

    /*<gContext.Provider value={{ data, dispatch }}>
      {props.children}
    </gContext.Provider>*/
  );
}
 
export default gContextProvider;