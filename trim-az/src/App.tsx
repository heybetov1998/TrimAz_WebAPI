import { Routes, Route } from "react-router-dom";
import MainLayout from "./layouts/MainLayout";
import Home from "./pages/Home";
import NotFound from "./pages/NotFound";

import "./App.css";
import Market from "./pages/Market";
import Barbershops from "./pages/Barbershops";
import Blogs from "./pages/Blogs";
import Contact from "./pages/Contact";
import BarbershopDetail from "./pages/BarbershopDetail";
import BarbershopSubLayout from "./layouts/BarbershopSubLayout";
import BarberDetail from "./pages/BarberDetail";
import BarberSubLayout from "./layouts/BarberSubLayout";
import Barbers from "./pages/Barbers";
import ProductDetail from "./pages/ProductDetail";
import MarketSubLayout from "./layouts/MarketSubLayout";
import Login from "./pages/Login";
import Register from "./pages/Register";
import BlogDetail from "./pages/BlogDetail";
import BlogSubLayout from "./layouts/BlogSubLayout";
import UserSettings from "./pages/UserSettings";

const App = () => (
    <Routes>
        <Route path="/" element={<MainLayout />}>
            <Route index element={<Home />} />

            <Route path="barbershops" element={<BarbershopSubLayout />}>
                <Route index element={<Barbershops />} />
                <Route path=":id" element={<BarbershopDetail />} />
                <Route path="*" element={<NotFound />} />
            </Route>

            <Route path="barbers" element={<BarberSubLayout />}>
                <Route index element={<Barbers />} />
                <Route path=":id" element={<BarberDetail />} />
                <Route path="*" element={<NotFound />} />
            </Route>

            <Route path="market" element={<MarketSubLayout />}>
                <Route index element={<Market />} />
                <Route path="products/:id" element={<ProductDetail />} />
                <Route path="*" element={<NotFound />} />
            </Route>

            <Route path="blogs" element={<BlogSubLayout />}>
                <Route index element={<Blogs />} />
                <Route path=":id" element={<BlogDetail />} />
                <Route path="*" element={<NotFound />} />
            </Route>

            <Route path="contact" element={<Contact />} />
            <Route path="login" element={<Login />} />
            <Route path="register" element={<Register />} />
            <Route path="users/:id/settings" element={<UserSettings />} />
            <Route path="*" element={<NotFound />} />
        </Route>
    </Routes>
);

export default App;
