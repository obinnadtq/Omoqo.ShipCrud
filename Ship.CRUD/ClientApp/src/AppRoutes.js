import CreatePage from "./components/CreatePage";
import { FetchData } from "./components/FetchData";
import Home from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/create',
    element: <CreatePage />
  },
  {
    path: '/detail/:id',
    element: <FetchData />
  }
];

export default AppRoutes;
