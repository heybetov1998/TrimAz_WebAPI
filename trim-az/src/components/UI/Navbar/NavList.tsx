import NavItem from "./NavItem";

const dataArray = [
    { where: "/", text: "Home" },
    { where: "/barbershops", text: "Barbershops" },
    // { where: "/women", text: "Women" },
    { where: "/market", text: "Market" },
    { where: "/blogs", text: "Blogs" },
    { where: "/contact", text: "Contact" },
];

const NavList = () => {
    return (
        <ul className="d-flex justify-content-center align-items-center h-100">
            {dataArray.map((data) => (
                <NavItem key={data.where} where={data.where} text={data.text} />
            ))}
        </ul>
    );
};

export default NavList;
