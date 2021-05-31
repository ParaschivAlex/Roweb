import { API_ROUTE } from "../config/api";
import Category from "../models/category";
import Product from "../models/product";

const ApiClient = {
  get: (url, headers = {}) => {
    return ApiClient.makeRequest(`${API_ROUTE}/${url}`, "GET", {}, headers);},
  post: (url, id, data) => {
    return ApiClient.makeRequest(`${API_ROUTE}/${url}`, "POST", {}, data);},
  put: (url, id, data) => {
    return ApiClient.makeRequest(`${API_ROUTE}/${url}`, "PUT", id, data);},
  delete: (url, id, headers = {}) => {
    return ApiClient.makeRequest(`${API_ROUTE}/${url}`, "DELETE", id, headers);
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

  GetCateg: async(id) => {
    return await ApiClient.get("category/{id}")
  },

  PostCateg: async (headers) => {
    return await ApiClient.post("category", headers);
    // console.log(categories);
    //return categories.map((c) => new Category(c.categoryId, c.name));
  },

  UpdateCateg: async (id, headers) => {
    return await ApiClient.put("category/{id}", headers);
  },

  DeleteCateg: async () => {
    return await ApiClient.delete("category{id}");
  },
};

const Products = {
  all: async () => {
    const { products } = await ApiClient.get("product");
    console.log(products);
    return products.map((p) => new Product(p.productId, p.name, p.description, p.price, p.baseprice, p.image, p.categoryId));
  },

  GetProduct: async(id) => {
    return await ApiClient.get("product/{id}")
  },

  PostProduct: async (headers) => {
    return await ApiClient.post("product", headers);
    // console.log(categories);
    //return categories.map((c) => new Category(c.categoryId, c.name));
  },

  UpdateProduct: async (id, headers) => {
    return await ApiClient.put("product/{id}", headers);
  },

  DeleteProduct: async () => {
    return await ApiClient.delete("product{id}");
  },
};
/*
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
*/
const ApiHelper = {
  ProductCategories,
  Products,
};
export default ApiHelper;
