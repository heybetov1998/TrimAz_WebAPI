import React from "react";
import { NavLink } from "react-router-dom";

type Props = {
    text: string;
    where: string;
    children?: React.ReactNode;
};

const NavItem: React.FC<Props> = (props) => {
    return (
        <li>
            <NavLink
                className={({ isActive }) =>
                    isActive ? "nav_item active" : "nav_item"
                }
                to={props.where}
            >
                {props.text}
            </NavLink>
        </li>
    );
};

export default NavItem;
