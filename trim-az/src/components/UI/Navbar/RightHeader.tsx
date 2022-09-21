import { Link, NavLink, useLocation } from "react-router-dom";
import { useState, useEffect } from "react";
import {
    BiBasket,
    BiUser,
    BiMenu,
    BiLogIn,
    BiPencil,
    BiLogOut,
} from "react-icons/bi";
import { IoIosSettings } from "react-icons/io";

type PropsType = {
    onClick?: () => void;
};

const RightHeader = (props: PropsType) => {
    const [isUserOptionsOpened, setIsUserOptionsOpened] = useState(false);
    const { pathname } = useLocation();

    useEffect(() => {
        setIsUserOptionsOpened(false);
    }, [pathname]);

    const optionsHandler = (event: React.MouseEvent) => {
        event.preventDefault();
        setIsUserOptionsOpened((prevState) => !prevState);
    };

    return (
        <div className="h-100 right_header">
            <ul className="h-100 d-flex justify-content-end align-items-center">
                <li>
                    <NavLink
                        className="right_item d-flex justify-content-center align-items-center"
                        to={"#"}
                    >
                        <BiBasket size={"1.4rem"} />
                    </NavLink>
                </li>
                <li>
                    <NavLink
                        className="right_item d-flex justify-content-center align-items-center"
                        to={"#"}
                        onClick={optionsHandler}
                    >
                        <BiUser size={"1.4rem"} />
                    </NavLink>
                    {isUserOptionsOpened && (
                        <ul className="user_manager_popup">
                            <li>
                                <Link to={"/login"}>
                                    <BiLogIn size={"1.2rem"} />
                                    <span className="popup_text">Login</span>
                                </Link>
                            </li>
                            <li>
                                <Link to={"/register"}>
                                    <BiPencil size={"1.2rem"} />
                                    <span className="popup_text">Register</span>
                                </Link>
                            </li>
                            <li>
                                <Link to={"/users/:id/settings"}>
                                    <IoIosSettings size={"1.2rem"} />
                                    <span className="popup_text">Settings</span>
                                </Link>
                            </li>
                            <li>
                                <Link to={"/logout"}>
                                    <BiLogOut size={"1.2rem"} />
                                    <span className="popup_text">Logout</span>
                                </Link>
                            </li>
                        </ul>
                    )}
                </li>
                <li className="d-md-none">
                    <NavLink
                        className="right_item d-flex justify-content-center align-items-center"
                        to={"#"}
                        onClick={props.onClick}
                    >
                        <BiMenu size={"1.4rem"} />
                    </NavLink>
                </li>
            </ul>
        </div>
    );
};

export default RightHeader;
