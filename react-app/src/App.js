import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import ContextProvider from "./contexts/context";
import NavBar from "./components/NavBar";
import LoginBar from "./components/LoginBar";
import Home from "./pages/Home";
import Product from "./pages/Product";
import Category from "./pages/Category";
import Order from "./pages/Order";
import Invoice from "./pages/Invoice";
import Report from "./pages/Report";
import Supplier from "./pages/Supplier";
import NotFound from "./pages/NotFound";

function App() {
  return (
    <ContextProvider>
    <Router>
    <div className="App">
      <LoginBar />
      <NavBar />
      <Switch>
        <Route exact path="/">
          <Home />
        </Route>
        <Route path="/supplier">
          <Supplier />
        </Route>
        <Route path="*">
          <NotFound />
        </Route>
      </Switch>
    </div>
    </Router> 
    </ContextProvider>
    
    /* <Route path="/category">
          <Category />
        </Route>
        <Route path="/invoice">
          <Invoice />
        </Route>
        <Route path="/order">
          <Order />
        </Route>
        <Route path="/report">
          <Report />
        </Route>
        */
  );
}

export default App;

