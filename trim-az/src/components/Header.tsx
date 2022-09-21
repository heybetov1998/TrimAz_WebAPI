import { useState, useEffect } from "react";
import BrandLogo from "./UI/Navbar/BrandLogo";
import HeaderNavigation from "./UI/Navbar/HeaderNavigation";
import NavList from "./UI/Navbar/NavList";
import RightHeader from "./UI/Navbar/RightHeader";
import Column from "./UI/grid/Column";
import ContainerFluid from "./UI/grid/ContainerFluid";
import Row from "./UI/grid/Row";
import { NavLink, useLocation } from "react-router-dom";

const dataArray = [
    { where: "/", text: "Home" },
    { where: "/barbershops", text: "Barbershops" },
    // { where: "/women", text: "Women" },
    { where: "/market", text: "Market" },
    { where: "/blogs", text: "Blogs" },
    { where: "/contact", text: "Contact" },
];

const Header = () => {
    const [isNavbarOpened, setIsNavbarOpened] = useState(false);
    const { pathname } = useLocation();

    useEffect(() => {
        setIsNavbarOpened(false);
    }, [pathname]);

    const navbarHandler = () => {
        setIsNavbarOpened((prevState) => !prevState);
    };

    return (
        <header className="main_header position-fixed top-0 start-0 end-0">
            <ContainerFluid>
                <Row>
                    <Column default={4} sm={2} md={2} lg={2} xl={2}>
                        <BrandLogo />
                    </Column>
                    <Column
                        className="d-none d-sm-none d-md-block"
                        md={8}
                        lg={8}
                        xl={8}
                    >
                        <HeaderNavigation>
                            <NavList />
                        </HeaderNavigation>
                    </Column>
                    <Column default={8} sm={10} md={2} lg={2} xl={2}>
                        <RightHeader onClick={navbarHandler} />
                    </Column>
                </Row>
            </ContainerFluid>
            <div className={`mini_navbar ${isNavbarOpened ? "active" : ""}`}>
                <ul>
                    {dataArray.map((data) => (
                        <li key={data.where}>
                            <NavLink className="link" to={data.where}>
                                {data.text}
                            </NavLink>
                        </li>
                    ))}
                </ul>
            </div>
        </header>
    );
};

export default Header;
