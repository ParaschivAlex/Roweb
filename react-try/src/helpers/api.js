import { API_ROUTE } from "../config/api";
import Category from "../models/category";
import Product from "../models/product";

const ApiClient = {
  get: (url, headers = {}) => {
    return ApiClient.makeRequest(`${API_ROUTE}/${url}`, "GET", {}, headers);},
  post: (url, headers = {}) => {
    return ApiClient.makeRequest(`${API_ROUTE}/${url}`, "POST", {}, headers);},
  put: (url, headers = {}) => {
    return ApiClient.makeRequest(`${API_ROUTE}/${url}`, "PUT", {}, headers);},
  delete: (url, headers = {}) => {
    return ApiClient.makeRequest(`${API_ROUTE}/${url}`, "DELETE", {}, headers);
  },
  makeRequest: async (url, type, params = {}, headers = {}) => {
    try {
      type = type.toUpperCase();
      const request = {
        method: type,
        headers: headers,
      };
      if (type === "POST" || type === "PUT") {
        request.body = JSON.stringify(params);
      }

      const result = await fetch(url, request);
      return await result.json();
    } catch (error) {
      throw error.message;
    }
  },
};

const ProductCategories = {
  all: async () => {
    const { categories } = await ApiClient.get("category");
    console.log(categories);
    return categories.map((c) => new Category(c.categoryId, c.name));
  },

  all: async () => {
    const { categories } = await ApiClient.post("category");
    // console.log(categories);
    return categories.map((c) => new Category(c.categoryId, c.name));
  },

  all: async () => {
    const { categories } = await ApiClient.put("category");
    // console.log(categories);
    return categories.map((c) => new Category(c.categoryId, c.name));
  },

  all: async () => {
    const { categories } = await ApiClient.delete("category");
    // console.log(categories);
    return categories.map((c) => new Category(c.categoryId, c.name));
  },
};

const Products = {
  all: async () => {
    const { products } = await ApiClient.get("product");
    console.log(products);
    return products.map((p) => new Product(p.productId, p.name, p.description, p.price, p.baseprice, p.image, p.categoryId));
  },

  all: async () => {
    const { products } = await ApiClient.post("product");
    console.log(products);
    return products.map((p) => new Product(p.productId, p.name, p.description, p.price, p.baseprice, p.image, p.categoryId));
  },

  all: async () => {
    const { products } = await ApiClient.put("product");
    console.log(products);
    return products.map((p) => new Product(p.productId, p.name, p.description, p.price, p.baseprice, p.image, p.categoryId));
  },

  all: async () => {
    const { products } = await ApiClient.delete("product");
    console.log(products);
    return products.map((p) => new Product(p.productId, p.name, p.description, p.price, p.baseprice, p.image, p.categoryId));
  },
};

const CreateProduct = (data, onSuccess) => dispatch => {
  data = formateData(data)
  api.dCandidate().create(data)
      .then(res => {
          dispatch({
              type: 'CREATE',
              payload: res.data
          })
          onSuccess()
      })
      .catch(err => console.log(err))
};

const CreateCategory = (data, onSuccess) => dispatch => {
  data = formateData(data)
  api.dCandidate().create(data)
      .then(res => {
          dispatch({
              type: 'CREATE',
              payload: res.data
          })
          onSuccess()
      })
      .catch(err => console.log(err))
};

const UpdateProduct = (id, data, onSuccess) => dispatch => {
  data = formateData(data)
  api.dCandidate().update(id, data)
      .then(res => {
          dispatch({
              type: 'UPDATE',
              payload: { id, ...data }
          })
          onSuccess()
      })
      .catch(err => console.log(err))
};

const UpdateCategory = (id, data, onSuccess) => dispatch => {
  data = formateData(data)
  api.dCandidate().update(id, data)
      .then(res => {
          dispatch({
              type: 'UPDATE',
              payload: { id, ...data }
          })
          onSuccess()
      })
      .catch(err => console.log(err))
};

const DeleteProduct = (id, onSuccess) => dispatch => {
  api.dCandidate().delete(id)
      .then(res => {
          dispatch({
              type: DELETE,
              payload: id
          })
          onSuccess()
      })
      .catch(err => console.log(err))
}

const DeleteCategory = (id, onSuccess) => dispatch => {
  api.dCandidate().delete(id)
      .then(res => {
          dispatch({
              type: 'DELETE',
              payload: id
          })
          onSuccess()
      })
      .catch(err => console.log(err))
}

const ApiHelper = {
  ProductCategories,
  Products,
  DeleteProduct,
  DeleteCategory,
  UpdateProduct,
  UpdateCategory,
  CreateProduct,
  CreateCategory,
};
export default ApiHelper;