import CreatePage from "./components/CreatePage";
import DetailPage from "./components/DetailPage";
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
    element: <DetailPage />
  }
];

export default AppRoutes;
