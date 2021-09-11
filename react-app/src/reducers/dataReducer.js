import {axios, get, post} from 'axios'

const getdata = (url) =>{
  const headers = {
    'Authorization': 'Bearer my-token',
    'My-Custom-Header': 'foobar'
  };
  get(url, { headers })
  //.then(response => this.setState({ totalReactPackages: response.data.total }))
  .then(response => {return response.data[0]} )
  .catch(error => {
      console.error('dataReducer:getdata error!', error);
  });
}


const getpostdata = (url) =>{
  const headers = {
    ///'Authorization': 'Bearer my-token',
    //'My-Custom-Header': 'foobar',
    'Content-Type': 'application/json'
  };
  //get(url, { headers })
  //get(url)
  //get(url, { headers }, { params: JSON.stringify({"_Orderby": "uomId", "_IsDesc": true})} )
  get(url, { params: {"_Orderby": "uomId", "_IsDesc": true}} )
  //.then(response => this.setState({ totalReactPackages: response.data.total }))
  .then(response => {console.log(response); return response.data} )
  .catch(error => {
      console.error('dataReducer:getdata error!', error);
  });

  /*axios({
    method: "get",
    url: url,
    params: {
      _Orderby: "uomId", _IsDesc: true
    }
    }).then(res => console.log(res.data));*/
}


export const dataReducer = (state, action) => {
  switch (action.type) {
    case 'GET_SUPPLIERS':
      return console.log(getpostdata('https://localhost:5001/api/uoms/getall/')); //[...state + action.toto + "toto3"];
    case 'REMOVE_BOOK':
      return state.filter(book => book.id !== action.id);
    default:
      return state;
  }
} 

//export default dataReducer;