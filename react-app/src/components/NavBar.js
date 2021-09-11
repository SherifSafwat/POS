import React from 'react'
import { NavLink } from "react-router-dom"

export default function NavBar() {
    return (
        <div>
            <button> Home </button>
            <button> Products </button>
            <NavLink to="/supplier" > Suppliers </NavLink>
            <button> Categories </button>
            <button> Invoices </button>
            <button> Orders </button>
        </div>
    )
}
