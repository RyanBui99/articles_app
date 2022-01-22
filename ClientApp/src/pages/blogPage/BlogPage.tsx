import React from 'react';
import NavbarComponent from '../../components/NavbarComponent';
import Grid from '@mui/material/Grid';
import { useDispatch } from 'react-redux';
import { useTypedSelector } from '../../hooks/useTypeSelector';
import { getBlogPosts } from '../../store/actionCreators/blogPostCreator';
import IStorageBlogPosts from '../../interfaces/IStorageBlogPosts';
import BlogPosts from '../../components/BlogPosts';
import Box from '@material-ui/core/Box';
import Container from '@mui/material/Container';

export default function BlogPage() {
  const { blogPosts } = useTypedSelector((state) => state.blogPosts);
  const dispatch = useDispatch();

  React.useEffect(() => {
    dispatch(getBlogPosts());
  }, [dispatch]);

  return (
    <>
      <NavbarComponent />
      <Container
        component='main'
        sx={{
          display: 'flex',
          justifyContent: 'center',
          marginTop: '2em',
        }}
        maxWidth='lg'
      >
        <Grid container spacing={3}>
          {blogPosts.map((blogPost: IStorageBlogPosts, key: number) => (
            <Grid key={key} xs={12} sm={6} md={4} item  >
              <BlogPosts blogPost={blogPost} />
            </Grid>
          ))}
        </Grid>
      </Container>
    </>
  );
}
