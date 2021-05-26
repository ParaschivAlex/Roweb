import React, { useState, useEffect } from "react";
import { Nav } from "react-bootstrap";
import { Link } from "react-router-dom";
import ApiHelper from "../helpers/api";
import "../style/sidebar.css";

const Sidebar = (props) => {
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    ApiHelper.ProductCategories.all().then((mappedApiCategories) => {
      setCategories(mappedApiCategories);
    });
  }, [props]);

  return (
    <Nav className="col-md-12 d-md-block bg-light sidebar">
      <div className="sidebar-sticky"></div>
      {categories.map((c) => (
        <Nav.Item>
          <Nav.Link as={Link} to={`/products/${c.categoryId}`}>
            {c.name}
          </Nav.Link>
        </Nav.Item>
      ))}
    </Nav>
  );
};

export default Sidebar;